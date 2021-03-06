

namespace IADocumentClassifier.API
{
    using AIDocumentClassifier.Cors.CustomEntities;
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Cors.Services;
    using IADocumentClassifier.Infrastructure.Data;
    using IADocumentClassifier.Infrastructure.Filters;
    using IADocumentClassifier.Infrastructure.Interface;
    using IADocumentClassifier.Infrastructure.Repositories;
    using IADocumentClassifier.Infrastructure.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    //using NSwag;
    //using NSwag.Generation.Processors.Security;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using OpenApiInfo = Microsoft.OpenApi.Models.OpenApiInfo;
    //using OpenApiSecurityScheme = NSwag.OpenApiSecurityScheme;

    /// <summary>
    /// Metodo de inicio o Meadowhall
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the containerName.
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(options => 
            { 
              options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
              //options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();
            services.AddDbContext<DocumentClassifierDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CognitiveServices")));

      

            //Resuelve dependencias para trabajar con SQL y con las interface de Repositorio y Services
            services.AddTransient<IDocumentsTypesRepository, DocumentTypeRepository>();
            services.AddTransient<IDocumentTypeServices, DocumentTypeServices>();

            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<ITagServices, TagServices>();

            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<IClientsServices, ClientsServices>();

            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IRolesServices, RolesServices>();

            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionsServices, PermissionsServices>();

            services.AddTransient<IClientDocumentTypeRepository, ClientDocumentTypeRepository>();
            services.AddTransient<IClientDocumentTypeServices, ClientDocumentTypeServices>();

            services.AddTransient<ISetupRepository, SetupRepository>();
            services.AddTransient<ISetupServices, SetupServices>();

            services.AddTransient<IRolesPermissionRepository, RolesPermissionRepository>();
            services.AddTransient<IRolesPermissionServices, RolesPermissionServices>();

            services.AddTransient<IRolesClientRepository, RolesClientRepositorycs>();
            services.AddTransient<IRolesClientServices, RolesClientServices>();

            services.AddTransient<IClientTagRepository, CientTagRepository>();
            services.AddTransient<IClientTagServices, ClientTagServices>();

            services.AddTransient<IBlobServices, BlobServices>();

            services.AddSingleton<IUrlServices>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UrlServices(absoluteUri);

            });

            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));

            //Resuelve dependencias para trabajar con CosmosDB 
            //services.AddTransient<IDocumentsTypesRepository, DocumentTypeCosmosDbRepository>();

            //Definicion de seguridad por JWT Token con Swagger
            //services.AddOpenApiDocument(document =>
            //{
            //    document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            //    {
            //        Type = OpenApiSecuritySchemeType.ApiKey,
            //        FileName = "Authorization",
            //        In = OpenApiSecurityApiKeyLocation.Header,
            //        Description = "Type into the textbox: Bearer {your JWT token}."
            //    });

            //    document.OperationProcessors.Add(
            //        new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            //});

            //para trabajar con swagger-para documentar la API
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "AI Document Classifier API", Version = "v1" });
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwaggerGen(Configuration => Configuration.IncludeXmlComments(xmlPath));

            // Configuración Seguridad de la aplicacion
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Authentication:Issuer"],
            //        ValidAudience = Configuration["Authentication:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetConnectionString("SecretKey")))
            //    };
            //});

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();

            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseOpenApi();
            //app.UseSwaggerUi3();
           
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AI Document Classifier API");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
