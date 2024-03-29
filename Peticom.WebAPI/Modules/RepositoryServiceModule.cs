using System.Reflection;
using Autofac;
using Peticom.Core.Repositories;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;
using Peticom.Repository;
using Peticom.Repository.Repositories;
using Peticom.Repository.UnitOfWorks;
using Peticom.Service.Mapping;
using Peticom.Service.Services;

namespace WebAPI.Modules;
using Module = Autofac.Module;

public class RepositoryServiceModule : Module
{
    //Autofac kullanmamızın avantajı: Ne kadar repository ve service class-interface var ise,
    //Hepsini tek tek implement etmek durumunda kalmıyoruz. Built-In injection özelliklerinde bu bulunmuyor.
    protected override void Load(ContainerBuilder builder)
    {
        //Autofac'te ilk önce class daha sonra interface eklenir.
        //Repository Generic bir generic class olduğu için RegisterGeneric kullandık.
        builder.RegisterGeneric(typeof(GenericRepository<>))
            .As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();

        //Generic service bir generic class olduğu için RegisterGeneric kullandık.
        builder.RegisterGeneric(typeof(GenericService<,>))
            .As(typeof(IGenericService<,>))
            .InstancePerLifetimeScope();

        //UnitOfWork Generic bir class olmadığı için RegisterType kullandık.
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        //builder.RegisterType<EmailService>().As<IEmailService>();
        
        //Projede service-repo interface-class'larının kullanıldığı yerlerin assembly'lerini alıyoruz.
        var apiAssembly = Assembly.GetExecutingAssembly();
        //Katman içerisinde herhangi bir class'ın tipini vermemiz, o katman için assembly almamız için yeterli.
        //Direkt katmanın kendisini de verebiliriz(NLayer.Repository) fakat tip ile almak daha güvenli.
        var repositoryAssembly = Assembly.GetAssembly(typeof(PeticomDbContext));
        var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
        
        //Assembly'lerini aldığımız katmanlarda 'Repository' anahtar kelimesi geçen class'ları bellek'e ekliyoruz.
        builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        //Assembly'lerini aldığımız katmanlarda 'Service' anahtar kelimesi geçen class'ları bellek'e ekliyoruz.
        builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        //InstancePerLifetimeScope => Scope -> Request başlayıp bitene kadar aynı instance'ı kullanır!
        //InstancePerDependency => Transient -> Herhangi bir interface nerede geçildiyse her seferinde yeni bir instance oluşturur!
    }
}