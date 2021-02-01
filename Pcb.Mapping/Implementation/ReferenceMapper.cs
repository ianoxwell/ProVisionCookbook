using Pcb.Database.Context.Models;
using Pcb.Dto.Reference;
using Pcb.Mapping.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcb.Mapping.Implementation
{
    public class ReferenceMapper : IReferenceMapper
    {
        public ReferenceMapper()
        {

        }

        public AllergyWarning MapRefToAllergyWarning(ReferenceItemEx dto)
        {
            return new AllergyWarning
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public CuisineType MapRefToCuisineType(ReferenceItemEx dto)
        {
            return new CuisineType
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public DishTag MapRefToDishTag(ReferenceItemEx dto)
        {
            return new DishTag
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public DishType MapRefToDishType(ReferenceItemEx dto)
        {
            return new DishType
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public Equipment MapRefToEquipment(ReferenceItemEx dto)
        {
            return new Equipment
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public HealthLabel MapRefToHealthLabel(ReferenceItemEx dto)
        {
            return new HealthLabel
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public IngredientFoodGroup MapRefToIngredientFoodGroup(ReferenceItemEx dto)
        {
            return new IngredientFoodGroup
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public IngredientState MapRefToIngredientState(ReferenceItemEx dto)
        {
            return new IngredientState
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public LogLevel MapRefToLogLevel(ReferenceItemEx dto)
        {
            return new LogLevel
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public PermissionGroup MapRefToPermissionGroup(ReferenceItemEx dto)
        {
            return new PermissionGroup
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                AltTitle = dto.AltTitle,
                OnlineId = dto.OnlineId,
                Symbol = dto.Symbol,
            };
        }

        public MeasurementUnit MapRefToMeasurementUnit(ReferenceItemMeasurement dto)
        {
            return new MeasurementUnit
            {
                Id = dto.Id,
                Title = dto.Title,
                MeasurementType = dto.MeasurementType,
                ShortName = dto.ShortName,
                AltShortName = dto.AltShortName,
                ConvertsToId = dto.ConvertsToId,
                Quantity = dto.Quantity,
                CountryCode = dto.CountryCode,
            };
        }
    }
}
