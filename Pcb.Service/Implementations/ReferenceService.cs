using Microsoft.Extensions.Logging;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Security;
using Pcb.Service.Interfaces;
using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Pcb.Database.Context.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using LogLevel = Pcb.Database.Context.Models.LogLevel;
using Pcb.Mapping.Implementation;
using Pcb.Mapping.Interface;

namespace Pcb.Service.Implementations
{
    internal class ReferenceService : ServiceBase<PcbDbContext>, IReferenceService
    {
        private IPcbSecurityService SecurityService { get; }
        private IReferenceMapper ReferenceMapper { get; }
        public ReferenceService(
            IPcbSecurityService securityService,
            IPcbConfiguration configurationService,
            IReferenceMapper referenceMapper,
            ILogger<ReferenceService> logger)
            : base(configurationService, logger)
        {
            SecurityService = securityService;
            ReferenceMapper = referenceMapper;
        }

        /// <summary>
        /// Gets all the references as a list.
        /// </summary>
        /// <param name="type">The enum reference type.</param>
        /// <returns>Large list of reference lists.</returns>
        public IEnumerable<ReferenceItemEx> GetAll(ReferenceType type)
        {
            var all = Get(type);
            if (all == null)
            {
                return null;
            }

            return all.ToList();
        }

        /// <summary>
        /// Gets the complete list of measurement reference items.
        /// </summary>
        /// <returns>IEnumerable of Measurement Units.</returns>
        public IEnumerable<MeasurementUnit> GetMeasurementUnits()
        {
            using var _db = GetReadOnlyDbContext();
            var queryList = _db.MeasurementUnit.ToList();
            return queryList;
        }


        /// <summary>
        /// Creates a new Reference Item.
        /// </summary>
        /// <param name="item">Reference Item dto.</param>
        /// <param name="type">The enum reference type.</param>
        /// <returns>Success as a boolean.</returns>
        public async Task<bool> Save(ReferenceItemEx item, ReferenceType type)
        {
            using var _db = GetReadWriteDbContext();
            switch (type)
            {
                case ReferenceType.AllergyWarning:
                    {
                        _db.AllergyWarning.Add(ReferenceMapper.MapRefToAllergyWarning(item));
                        break;
                    }
                case ReferenceType.CuisineType:
                    {
                        _db.CuisineType.Add(ReferenceMapper.MapRefToCuisineType(item));
                        break;
                    }
                case ReferenceType.DishTag:
                    {
                        _db.DishTag.Add(ReferenceMapper.MapRefToDishTag(item));
                        break;
                    }
                case ReferenceType.DishType:
                    {
                        _db.DishType.Add(ReferenceMapper.MapRefToDishType(item));
                        break;
                    }
                case ReferenceType.Equipment:
                    {
                        _db.Equipment.Add(ReferenceMapper.MapRefToEquipment(item));
                        break;
                    }
                case ReferenceType.HealthLabel:
                    {
                        _db.HealthLabel.Add(ReferenceMapper.MapRefToHealthLabel(item));
                        break;
                    }
                case ReferenceType.IngredientFoodGroup:
                    {
                        _db.IngredientFoodGroup.Add(ReferenceMapper.MapRefToIngredientFoodGroup(item));
                        break;
                    }
                case ReferenceType.IngredientState:
                    {
                        _db.IngredientState.Add(ReferenceMapper.MapRefToIngredientState(item));
                        break;
                    }
                case ReferenceType.LogLevel:
                    {
                        _db.LogLevel.Add(ReferenceMapper.MapRefToLogLevel(item));
                        break;
                    }
                default:
                    {
                        _db.PermissionGroup.Add(ReferenceMapper.MapRefToPermissionGroup(item));
                        break;
                    }
            }
            int success = await _db.SaveChangesAsync();
            return success > 0;
        }

        /// <summary>
        /// Creates a new measurement reference item.
        /// </summary>
        /// <param name="item">the Measurement reference dto.</param>
        /// <returns>Success as a boolean.</returns>
        public async Task<bool> CreateMeasurement(ReferenceItemMeasurement item)
        {
            using var _db = GetReadWriteDbContext();
            var mapped = ReferenceMapper.MapRefToMeasurementUnit(item);
            _db.MeasurementUnit.Add(mapped);
            int success = await _db.SaveChangesAsync();
            return success > 0;
        }

        /// <summary>
        /// Checks if any reference items of this title have been already created.
        /// </summary>
        /// <param name="name">string name / title to check</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ReferenceItemExists(string name, ReferenceType type)
        {
            using var _db = GetReadOnlyDbContext();
            IEnumerable<dynamic> dbEntity = _db.FindEntity(type.ToString());
            dynamic value = dbEntity.First(a => a?.Title.ToLower().Trim() == name.ToLower().Trim());
            return value ? value.id : 0;

        }

        /// <summary>
        /// Gets list of single reference type.
        /// </summary>
        /// <param name="type">The enum reference type.</param>
        /// <returns>List of the reference type.</returns>
        private IEnumerable<ReferenceItemEx> Get(ReferenceType type)
        {
            // Suppress transactions for ref data read.
            // We're potentially inside a writing transaction and we need to prevent locking.
            using var db = GetReadOnlyDbContext();
            List<ReferenceItemEx> items = new List<ReferenceItemEx>();
            var queryObj = db.FindEntity(type.ToString());
            foreach (var row in queryObj)
            {
                var item = new ReferenceItemEx
                {
                    Id = row.Id,
                    Title = row.Title,
                    Symbol = row.Symbol,
                    Summary = row.Summary,
                    AltTitle = row.AltTitle,
                    OnlineId = row.OnlineId,
                    CreatedAt = row.CreatedAt,
                    RowVer = row.RowVer
                };
                if (row.GetType().GetProperty("SortOrder") != null)
                {
                    item.SortOrder = row.SortOrder;
                }
                items.Add(item);
            }
            return items;
        }


    }
}
