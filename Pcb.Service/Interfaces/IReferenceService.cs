using Pcb.Database.Context.Models;
using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pcb.Service.Interfaces
{
    public interface IReferenceService
    {

        /// <summary>
        /// Gets all reference items, including ended, for a type.
        /// Cached.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        IEnumerable<ReferenceItemEx> GetAll(ReferenceType type);

        /// <summary>
        /// Gets all reference items, including ended, for a type.
        /// Cached.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        IEnumerable<MeasurementUnit> GetMeasurementUnits();

        /// <summary>
        /// Saves a reference item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="type">The Reference Type.</param>
        /// <returns></returns>
        Task<bool> Save(ReferenceItemEx item, ReferenceType type);

        /// <summary>
        /// Creates a measurement reference item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> CreateMeasurement(ReferenceItemMeasurement item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The title or name to check</param>
        /// <param name="type">The Reference Type.</param>
        /// <returns></returns>
        int ReferenceItemExists(string name, ReferenceType type);
    }
}
