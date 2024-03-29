﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Mapping.Interface;
using Pcb.Security;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcb.Service.Implementations
{
    internal class RawFoodService : ServiceBase<PcbDbContext>, IRawFoodService
    {
#pragma warning disable IDE0052 // Remove unread private members
        private IPcbSecurityService SecurityService { get; }
#pragma warning restore IDE0052 // Remove unread private members

        private IRawFoodMapper RawFoodMapper { get; }
        public RawFoodService(
            IPcbSecurityService securityService,
            IPcbConfiguration configurationService,
            IRawFoodMapper rawFoodMapper,
            ILogger<IngredientService> logger)
            : base(configurationService, logger)
        {
            SecurityService = securityService;
            RawFoodMapper = rawFoodMapper;
        }

        public async Task<PagedResult<RawFoodDto>> SearchIngredients(
            int pageSize = 25,
            int page = 1,
            string sort = "name",
            string order = "asc",
            string filter = "",
            int foodGroupId = 0)
        {
            var p = page > 0 ? page : 0;
            using var _db = GetReadOnlyDbContext();
            var skip = p * pageSize;
            var ingredientArray = _db.RawFoodUsda
                .Skip(skip)
                .Take(pageSize)
                .Where(l => (string.IsNullOrEmpty(filter) || l.Name.Contains(filter))
                    && (foodGroupId == 0 || l.FoodGroup.Id == foodGroupId));

            ingredientArray = order.Equals("asc", StringComparison.OrdinalIgnoreCase)
                ? ingredientArray.OrderByMember(sort)
                : ingredientArray.OrderByMemberDescending(sort);

            var finishedIngredientArray = await ingredientArray
                .Include(x => x.FoodGroup)
                .ToListAsync();

            PagedResult<RawFoodDto> pagedRawResult = new PagedResult<RawFoodDto>
            {
                TotalCount = await _db.RawFoodUsda.CountAsync()
            };
            foreach (var ingredient in finishedIngredientArray)
            {
                pagedRawResult.Items.Add(RawFoodMapper.MapRawFoodUsdaToDto(ingredient));
            }
            return pagedRawResult;
        }

        public async Task<RawFoodDto> ReadSingleIngredient(int usdaId)
        {
            using var _db = GetReadOnlyDbContext();
            RawFoodUsda ingredientObj = await _db.RawFoodUsda
                .Where(x => x.UsdaFoodId == usdaId)
                .Include(x => x.FoodGroup)
                .FirstOrDefaultAsync();

            return RawFoodMapper.MapRawFoodUsdaToDto(ingredientObj);
        }


        public async Task<List<SuggestedRawFoodDto>> SuggestedIngredient(string filter = "", int pageSize = 10, int foodGroupId = 0)
        {
            using var _db = GetReadOnlyDbContext();

            var finishedList = await _db.RawFoodUsda.Where(l => (l.Name.Contains(filter))
                    && (foodGroupId == 0 || l.FoodGroup.Id == foodGroupId))
                                        .Take(pageSize)
                                        .Include(x => x.FoodGroup)
                                        //.Select(p => new { p.Id, p.Name })
                                        .OrderByMemberDescending("Name")
                                        .ToListAsync();
            var suggestionList = new List<SuggestedRawFoodDto>();
            foreach (var suggestion in finishedList)
            {
                suggestionList.Add(new SuggestedRawFoodDto
                {
                    Id = suggestion.Id,
                    Name = suggestion.Name,
                    FoodGroup = suggestion.FoodGroup.Title,
                    UsdaId = suggestion.UsdaFoodId.ToString()

                });
            }
            return suggestionList;
        }



    }
}
