using PlatformService.Models;

    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CeatePlatform(Platform plat);
    }