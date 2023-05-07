using Microsoft.EntityFrameworkCore;
using InlandMarina.Data;

namespace InlandMarina.Models
{
    /// <summary>
    /// methods for working with Slips table in InlandMarina database
    /// </summary>
    public class SlipManager
    {
        /// <summary>
        /// retrieve  all Slips
        /// </summary>
        /// <param name="db">InlandMarina context Object</param>
        /// <returns>list of movies or null if none</returns>
        public static List<Slip> GetSlips(InlandMarinaContext db) // dependency injection
        {
            List<Slip> slips = null;
            
            List<int> leasedSlipsIDS = db.Leases.Select(l => l.SlipID).ToList(); // get leased slips' Ids to filter leased slips

            slips = db.Slips.Include(d => d.Dock).Where(s => !leasedSlipsIDS.Contains(s.ID)).ToList(); // get available slips
            
            return slips;
        }
        /// <summary>
        /// Get slips by dock
        /// </summary>
        /// <param name="db">InlandMarina context Object</param>
        /// <param name="dockId">dock id</param>
        /// <returns></returns>

        public static List<Slip> GetSlipsByDock(InlandMarinaContext db, int dockId)
        {
         
            List<Slip> slips = db.Slips.Where(s => s.DockID == dockId).
                Include(m => m.Dock).OrderBy(m => m.ID).ToList();
            return slips;
        }
    }

}

