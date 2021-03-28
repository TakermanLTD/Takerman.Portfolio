﻿using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Takerman.Portfolio.Web.Domain
{
    public class GetFeaturesByIdRangeQueryHandler
        : IQueryHandler<GetFeaturesByIdRangeQuery, IDictionary<int, Feature>>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;

        public GetFeaturesByIdRangeQueryHandler(
            IContentRepository contentRepository
            )
        {
            _contentRepository = contentRepository;
        }

        public async Task<IDictionary<int, Feature>> ExecuteAsync(GetFeaturesByIdRangeQuery query, IExecutionContext executionContext)
        {
            var features = await _contentRepository
                .CustomEntities()
                .GetByIdRange(query.FeatureIds)
                .AsRenderSummaries()
                .MapItem(MapFeature)
                .ExecuteAsync();

            return features;
        }

        private Feature MapFeature(CustomEntityRenderSummary customEntity)
        {
            var feature = new Feature();

            feature.FeatureId = customEntity.CustomEntityId;
            feature.Title = customEntity.Title;

            return feature;
        }
    }
}