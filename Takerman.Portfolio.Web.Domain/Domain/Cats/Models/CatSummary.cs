﻿using Cofoundry.Domain;

namespace Takerman.Portfolio.Web.Domain
{
    /// <summary>
    /// The difference between the CatDetails and CatSummary model
    /// is small, but it illustrates how the CQS lets us tailor
    /// models returned from queries to fit different situations.
    /// </summary>
    public class CatSummary
    {
        public int CatId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalLikes { get; set; }

        public ImageAssetRenderDetails MainImage { get; set; }
    }
}