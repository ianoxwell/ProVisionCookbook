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

namespace Pcb.Service.Implementations
{
    internal class ReferenceService : ServiceBase<PcbDbContext>, IReferenceService
    {
        private IPcbSecurityService SecurityService { get; }
        public ReferenceService(
            IPcbSecurityService securityService,
            IPcbConfiguration configurationService,
            ILogger<ReferenceService> logger)
            : base(configurationService, logger)
        {
            SecurityService = securityService;
        }

        public IEnumerable<ReferenceItemEx> GetAll(ReferenceType type)
        {
            var all = Get(type);
            if (all == null)
            {
                return null;
            }

            return all.ToList();
        }

        public IEnumerable<MeasurementUnit> GetMeasurementUnits()
        {
            // Suppress transactions for ref data read.
            // We're potentially inside a writing transaction and we need to prevent locking.
            using (var tranScope = GetSuppressedTransactionScope())
            using (var db = GetReadOnlyDbContext())
            {
                var queryList = db.MeasurementUnit.ToList();
                return queryList;
            }
        }


        public async Task<ReferenceItemEx> Save(IReferenceItemEx item, ReferenceType type)
        {
            using (var _db = GetReadOnlyDbContext())
            {

                var tableName = $"ref.{type.ToString()}";
                // var testThing = _db.GetType().GetMethod(type.ToString()).ReturnType;
                //var dbEntity = _db.FindEntity(type.ToString());
                //dbEntity.Add(item);
                //dbEntity.Entity.Add(item);
                //_db.AllergyWarning.Add(item);
                //dbEntity.Add();

                // check 
                await _db.SaveChangesAsync();
                return (ReferenceItemEx)item;
            }
        }

        public bool ReferenceItemExists(string name, ReferenceType type)
        {
            using (var _db = GetReadOnlyDbContext())
            {
                IEnumerable<dynamic> dbEntity = _db.FindEntity(type.ToString());
                bool value = dbEntity.Any(a => a?.Title.ToLower().Trim() == name.ToLower().Trim());
                return value;
            }

        }

        private IEnumerable<ReferenceItemEx> Get(ReferenceType type)
        {
            // Suppress transactions for ref data read.
            // We're potentially inside a writing transaction and we need to prevent locking.
            using (var tranScope = GetSuppressedTransactionScope())
            using (var db = GetReadOnlyDbContext())
            {
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
}
