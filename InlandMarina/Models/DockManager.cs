using InlandMarina.Data;

namespace InlandMarina.Models
{
    public class DockManager
    {
        /// <summary>
        /// Gets all docks
        /// </summary>
        /// <param name="db">InalandMarina Context Db</param>
        /// <returns> returns all docks or null</returns>
        public static List<Dock> GetDocks(InlandMarinaContext db) // dependency injection
        {
            List<Dock>? docks = null;

            docks = db.Docks.ToList();

            return docks;
        }
    }
}
