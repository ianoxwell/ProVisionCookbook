using Pcb.Database.Context.Models;
using Pcb.Dto.Recipes;
using Pcb.Dto.Reference;
using Pcb.Mapping.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Pcb.Mapping.Implementation
{
    public class RecipeMapper : IRecipeMapper
    {
        private IIngredientMapper IngredientMapper { get; }
        public RecipeMapper(IIngredientMapper ingredientMapper)
        {
            IngredientMapper = ingredientMapper;
        }
        public List<ReferenceItemEx> MapAllergyWarningToList(IEnumerable<RecipeAllergyWarning> map)
        {
            if (map == null) { return null; }
            List<ReferenceItemEx> refList = new List<ReferenceItemEx>();
            foreach (var warning in map.ToList())
            {
                refList.Add(new ReferenceItemEx
                {
                    Id = warning.AllergyWarning.Id,
                    Title = warning.AllergyWarning.Title,
                    Summary = warning.AllergyWarning.Summary,
                    Symbol = warning.AllergyWarning.Symbol,
                    RowVer = warning.AllergyWarning.RowVer,
                    SortOrder = null,
                    CreatedAt = warning.AllergyWarning.CreatedAt

                });

            }
            return refList;
        }


        public List<ReferenceItemEx> MapRecipeCuisineTypesToList(IEnumerable<RecipeCuisineType> map)
        {
            if (map == null) { return null; }
            List<ReferenceItemEx> refList = new List<ReferenceItemEx>();
            foreach (var refItem in map.ToList())
            {
                refList.Add(new ReferenceItemEx
                {
                    Id = refItem.CuisineType.Id,
                    Title = refItem.CuisineType.Title,
                    Summary = refItem.CuisineType.Summary,
                    Symbol = refItem.CuisineType.Symbol,
                    RowVer = refItem.CuisineType.RowVer,
                    SortOrder = null,
                    CreatedAt = refItem.CuisineType.CreatedAt

                });

            }
            return refList;
        }

        public List<ReferenceItemEx> MapRecipeDishTagsToList(IEnumerable<RecipeDishTag> map)
        {
            if (map == null) { return null; }
            List<ReferenceItemEx> refList = new List<ReferenceItemEx>();
            foreach (var refItem in map.ToList())
            {
                refList.Add(new ReferenceItemEx
                {
                    Id = refItem.DishTag.Id,
                    Title = refItem.DishTag.Title,
                    Summary = refItem.DishTag.Summary,
                    Symbol = refItem.DishTag.Symbol,
                    RowVer = refItem.DishTag.RowVer,
                    SortOrder = null,
                    CreatedAt = refItem.DishTag.CreatedAt

                });

            }
            return refList;
        }

        public List<ReferenceItemEx> MapRecipeDishTypesToList(IEnumerable<RecipeDishType> map)
        {
            if (map == null) { return null; }
            List<ReferenceItemEx> refList = new List<ReferenceItemEx>();
            foreach (var refItem in map.ToList())
            {
                refList.Add(new ReferenceItemEx
                {
                    Id = refItem.DishType.Id,
                    Title = refItem.DishType.Title,
                    Summary = refItem.DishType.Summary,
                    Symbol = refItem.DishType.Symbol,
                    RowVer = refItem.DishType.RowVer,
                    SortOrder = null,
                    CreatedAt = refItem.DishType.CreatedAt

                });

            }
            return refList;
        }

        public List<ReferenceItemEx> MapRecipeHealthLabelsToList(IEnumerable<RecipeHealthLabel> map)
        {
            if (map == null) { return null; }
            List<ReferenceItemEx> refList = new List<ReferenceItemEx>();
            foreach (var refItem in map.ToList())
            {
                refList.Add(new ReferenceItemEx
                {
                    Id = refItem.HealthLabel.Id,
                    Title = refItem.HealthLabel.Title,
                    Summary = refItem.HealthLabel.Summary,
                    Symbol = refItem.HealthLabel.Symbol,
                    RowVer = refItem.HealthLabel.RowVer,
                    SortOrder = null,
                    CreatedAt = refItem.HealthLabel.CreatedAt

                });

            }
            return refList;
        }

        public List<RecipeSteppedInstructionDto> MapSteppedInstructionsToDtoList(IEnumerable<RecipeSteppedInstruction> map)
        {
            if (map == null) { return null; }
            List<RecipeSteppedInstructionDto> itemList = new List<RecipeSteppedInstructionDto>();
            map = map.OrderBy(x => x.StepNumber);
            foreach (var item in map.ToList())
            {
                itemList.Add(new RecipeSteppedInstructionDto
                {
                    Id = item.Id,
                    RecipeId = item.RecipeId,
                    StepNumber = item.StepNumber,
                    StepDescription = item.StepDescription,
                    RowVer = item.RowVer,
                    CreatedAt = item.CreatedAt
                });
            }
            return itemList;
        }


        public List<RecipeIngredientListDto> MapRecipeIngredientsDtoList(IEnumerable<RecipeIngredientList> map)
        {
            if (map == null) { return null; }
            List<RecipeIngredientListDto> itemList = new List<RecipeIngredientListDto>();
            foreach (var item in map.ToList())
            {
                itemList.Add(new RecipeIngredientListDto
                {
                    Id = item.Id,
                    RecipeId = item.RecipeId,
                    IngredientId = item.IngredientId,
                    Ingredient = IngredientMapper.MapIngredientToDto(item.Ingredient),
                    Quantity = item.Quantity,
                    Preference = item.Preference,
                    IngredientState = IngredientMapper.MapIngredientStateToDto(item.IngredientState),
                    MeasurementUnit = IngredientMapper.MapMeasurementToDto(item.MeasurementUnit),
                    RowVer = item.RowVer,
                    CreatedAt = item.CreatedAt
                });

            }
            return itemList;
        }

        public List<RecipePictureDto> MapRecipePicturesDtoList(IEnumerable<RecipePicture> map)
        {
            if (map == null) { return null; }
            List<RecipePictureDto> itemList = new List<RecipePictureDto>();
            foreach (var item in map.ToList())
            {
                itemList.Add(new RecipePictureDto
                {
                    Id = item.Id,
                    RecipeId = item.RecipeId,
                    Title = item.Title,
                    FileLink = item.FileLink,
                    Picture = item.Picture,
                    PicturePosition = item.PicturePosition,
                    RowVer = item.RowVer,
                    CreatedAt = item.CreatedAt
                });

            }
            return itemList;
        }

        public List<RecipeReviewDto> MapRecipeReviewsDtoList(IEnumerable<RecipeReview> map)
        {
            if (map == null) { return null; }
            List<RecipeReviewDto> itemList = new List<RecipeReviewDto>();
            foreach (var item in map.ToList())
            {
                itemList.Add(new RecipeReviewDto
                {
                    Id = item.Id,
                    RecipeId = item.RecipeId,
                    Title = item.Title,
                    Review = item.Review,
                    Rating = item.Rating,
                    UserId = item.UserId,
                    RowVer = item.RowVer,
                    CreatedAt = item.CreatedAt
                });

            }
            return itemList;
        }

        public RecipeDto MapRecipeToDto(Recipe dbObj)
        {
            if (dbObj == null) { return null; }
            return new RecipeDto
            {
                Id = dbObj.Id,
                Name = dbObj.Name,
                Teaser = dbObj.Teaser,
                NumberOfServings = dbObj.NumberOfServings,
                PriceEstimate = dbObj.PriceEstimate,
                PrepTime = dbObj.PrepTime,
                CookTime = dbObj.CookTime,
                ReadyInMinutes = dbObj.ReadyInMinutes,
                RawInstructions = dbObj.RawInstructions,
                CreateByUserId = dbObj.CreateByUserId,
                SourceOfRecipeLink = dbObj.SourceOfRecipeLink,
                SourceOfRecipeName = dbObj.SourceOfRecipeName,
                SpoonacularId = dbObj.SpoonacularId,
                CreditsText = dbObj.CreditsText,
                NumberStars = dbObj.NumberStars,
                NumberFavourites = dbObj.NumberFavourites,
                NumberOfTimesCooked = dbObj.NumberOfTimesCooked,
                AllergyWarnings = MapAllergyWarningToList(dbObj.RecipeAllergyWarning),
                RecipeCuisineTypes = MapRecipeCuisineTypesToList(dbObj.RecipeCuisineType),
                RecipeDishTags = MapRecipeDishTagsToList(dbObj.RecipeDishTag),
                RecipeDishTypes = MapRecipeDishTypesToList(dbObj.RecipeDishType),
                RecipeHealthLabels = MapRecipeHealthLabelsToList(dbObj.RecipeHealthLabel),
                SteppedInstructions = MapSteppedInstructionsToDtoList(dbObj.SteppedInstruction),
                RecipeIngredientLists = MapRecipeIngredientsDtoList(dbObj.RecipeIngredientList),
                RecipeReviews = MapRecipeReviewsDtoList(dbObj.RecipeReview),
                RecipePictures = MapRecipePicturesDtoList(dbObj.RecipePicture),
                RowVer = dbObj.RowVer,
                CreatedAt = dbObj.CreatedAt
            };
        }

        public RecipeDto MapRecipeToShortDto(Recipe dbObj)
        {
            if (dbObj == null) { return null; }
            return new RecipeDto
            {
                Id = dbObj.Id,
                Name = dbObj.Name,
                Teaser = dbObj.Teaser,
                NumberOfServings = dbObj.NumberOfServings,
                PriceEstimate = dbObj.PriceEstimate,
                PrepTime = dbObj.PrepTime,
                CookTime = dbObj.CookTime,
                ReadyInMinutes = dbObj.ReadyInMinutes,
                RawInstructions = dbObj.RawInstructions,
                CreateByUserId = dbObj.CreateByUserId,
                SourceOfRecipeLink = dbObj.SourceOfRecipeLink,
                SourceOfRecipeName = dbObj.SourceOfRecipeName,
                SpoonacularId = dbObj.SpoonacularId,
                CreditsText = dbObj.CreditsText,
                NumberStars = dbObj.NumberStars,
                NumberFavourites = dbObj.NumberFavourites,
                NumberOfTimesCooked = dbObj.NumberOfTimesCooked,
                RecipeReviews = MapRecipeReviewsDtoList(dbObj.RecipeReview),
                RecipePictures = MapRecipePicturesDtoList(dbObj.RecipePicture),
                RowVer = dbObj.RowVer,
                CreatedAt = dbObj.CreatedAt
            };
        }

        public Recipe MapDtoToRecipe(RecipeDto dto)
        {
            if (dto == null) { return null; }
            return new Recipe
            {
                Name = dto.Name,
                Teaser = dto.Teaser,
                NumberOfServings = dto.NumberOfServings,
                PriceEstimate = dto.PriceEstimate,
                PrepTime = dto.PrepTime,
                CookTime = dto.CookTime,
                ReadyInMinutes = dto.ReadyInMinutes,
                RawInstructions = dto.RawInstructions,
                CreateByUserId = dto.CreateByUserId,
                SourceOfRecipeName = dto.SourceOfRecipeName,
                SourceOfRecipeLink = dto.SourceOfRecipeLink,
                SpoonacularId = dto.SpoonacularId,
                CreditsText = dto.CreditsText,
                NumberStars = dto.NumberStars,
                NumberFavourites = dto.NumberFavourites,
                NumberOfTimesCooked = dto.NumberOfTimesCooked,
                RecipeAllergyWarning = dto.AllergyWarnings?.Select(x => MapDtoToRecipeAllergyWarningMapping(x, dto.Id)).ToList(),
                RecipeCuisineType = dto.RecipeCuisineTypes?.Select(x => MapDtoToRecipeCuisineTypeMapping(x, dto.Id)).ToList(),
                RecipeDishTag = dto.RecipeDishTags?.Select(x => MapDtoToRecipeDishTagMapping(x, dto.Id)).ToList(),
                RecipeDishType = dto.RecipeDishTypes?.Select(x => MapDtoToRecipeDishTypeMapping(x, dto.Id)).ToList(),
                RecipeHealthLabel = dto.RecipeHealthLabels?.Select(x => MapDtoToRecipeHealthLabelMapping(x, dto.Id)).ToList(),
                SteppedInstruction = dto.SteppedInstructions?.Select(x => MapDtoToSteppedInstructionMapping(x, dto.Id)).ToList(),
                RecipeIngredientList = dto.RecipeIngredientLists?.Select(x => MapDtoToRecipeIngredientMapping(x, dto.Id)).ToList(),
                RecipeReview = dto.RecipeReviews?.Select(x => MapDtoToRecipeReviewMapping(x, dto.Id)).ToList(),
                RecipePicture = dto.RecipePictures?.Select(x => MapDtoToRecipePictureMapping(x, dto.Id)).ToList()
            };
        }



        public Recipe UpdateRecipeWithDto(Recipe updateObj, RecipeDto dto)
        {
            if (dto == null || updateObj == null) { return null; }
            updateObj.Name = dto.Name;
            updateObj.Teaser = dto.Teaser;
            updateObj.NumberOfServings = dto.NumberOfServings;
            updateObj.PriceEstimate = dto.PriceEstimate;
            updateObj.PrepTime = dto.PrepTime;
            updateObj.CookTime = dto.CookTime;
            updateObj.ReadyInMinutes = dto.ReadyInMinutes;
            updateObj.RawInstructions = dto.RawInstructions;
            updateObj.CreateByUserId = dto.CreateByUserId;
            updateObj.SourceOfRecipeLink = dto.SourceOfRecipeLink;
            updateObj.CreditsText = dto.CreditsText;
            updateObj.NumberStars = dto.NumberStars;
            updateObj.NumberFavourites = dto.NumberFavourites;
            updateObj.NumberOfTimesCooked = dto.NumberOfTimesCooked;
            updateObj.RecipeAllergyWarning = dto.AllergyWarnings.Select(x => MapDtoToRecipeAllergyWarningMapping(x, dto.Id)).ToList();
            updateObj.RecipeCuisineType = dto.RecipeCuisineTypes.Select(x => MapDtoToRecipeCuisineTypeMapping(x, dto.Id)).ToList();
            updateObj.RecipeDishTag = dto.RecipeDishTags.Select(x => MapDtoToRecipeDishTagMapping(x, dto.Id)).ToList();
            updateObj.RecipeDishType = dto.RecipeDishTypes.Select(x => MapDtoToRecipeDishTypeMapping(x, dto.Id)).ToList();
            updateObj.RecipeHealthLabel = dto.RecipeHealthLabels.Select(x => MapDtoToRecipeHealthLabelMapping(x, dto.Id)).ToList();
            updateObj.SteppedInstruction = dto.SteppedInstructions.Select(x => MapDtoToSteppedInstructionMapping(x, dto.Id)).ToList();
            updateObj.RecipeIngredientList = dto.RecipeIngredientLists.Select(x => MapDtoToRecipeIngredientMapping(x, dto.Id)).ToList();
            updateObj.RecipeReview = dto.RecipeReviews.Select(x => MapDtoToRecipeReviewMapping(x, dto.Id)).ToList();
            updateObj.RecipePicture = dto.RecipePictures.Select(x => MapDtoToRecipePictureMapping(x, dto.Id)).ToList();

            return updateObj;
        }

        private RecipeAllergyWarning MapDtoToRecipeAllergyWarningMapping(IReferenceItemEx map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeAllergyWarning
            {
                RecipeId = recipeId,
                AllergyWarningId = map.Id
            };
        }
        private RecipeCuisineType MapDtoToRecipeCuisineTypeMapping(IReferenceItemEx map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeCuisineType
            {
                RecipeId = recipeId,
                CuisineTypeId = map.Id
            };
        }
        private RecipeDishTag MapDtoToRecipeDishTagMapping(IReferenceItemEx map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeDishTag
            {
                RecipeId = recipeId,
                DishTagId = map.Id
            };
        }
        private RecipeDishType MapDtoToRecipeDishTypeMapping(IReferenceItemEx map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeDishType
            {
                RecipeId = recipeId,
                DishTypeId = map.Id

            };
        }
        private RecipeHealthLabel MapDtoToRecipeHealthLabelMapping(IReferenceItemEx map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeHealthLabel
            {
                RecipeId = recipeId,
                HealthLabelId = map.Id

            };
        }
        private RecipeIngredientList MapDtoToRecipeIngredientMapping(RecipeIngredientListDto map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeIngredientList
            {
                RecipeId = recipeId,
                IngredientId = map.IngredientId,
                Quantity = map.Quantity,
                Preference = map.Preference,
                IngredientStateId = map.IngredientState?.Id == null ? 0 : map.IngredientState.Id,
                MeasurementUnitId = map.MeasurementUnit.Id
            };
        }
        private RecipeSteppedInstruction MapDtoToSteppedInstructionMapping(RecipeSteppedInstructionDto map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeSteppedInstruction
            {
                RecipeId = recipeId,
                StepNumber = map.StepNumber,
                StepDescription = map.StepDescription
            };
        }
        private RecipeReview MapDtoToRecipeReviewMapping(RecipeReviewDto map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipeReview
            {
                RecipeId = recipeId,
                Title = map.Title,
                Review = map.Review,
                Rating = map.Rating,
                UserId = map.UserId
            };
        }
        private RecipePicture MapDtoToRecipePictureMapping(RecipePictureDto map, int recipeId)
        {
            if (map == null) { return null; }
            return new RecipePicture
            {
                RecipeId = recipeId,
                Title = map.Title,
                FileLink = map.FileLink,
                Picture = map.Picture,
                PicturePosition = map.PicturePosition
            };
        }
    }
}
