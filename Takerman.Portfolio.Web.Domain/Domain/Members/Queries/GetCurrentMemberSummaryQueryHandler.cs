﻿using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using System.Threading.Tasks;

namespace Takerman.Portfolio.Web.Domain
{
    /// <summary>
    /// Query to get some information about the currently logged in user. We can use
    /// IIgnorePermissionCheckHandler here because if the user is not logged in then
    /// we return null, so there's no need for a permission check.
    /// </summary>
    public class GetCurrentMemberSummaryQueryHandler
        : IQueryHandler<GetCurrentMemberSummaryQuery, MemberSummary>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;

        public GetCurrentMemberSummaryQueryHandler(
            IContentRepository contentRepository
            )
        {
            _contentRepository = contentRepository;
        }

        public async Task<MemberSummary> ExecuteAsync(GetCurrentMemberSummaryQuery query, IExecutionContext executionContext)
        {
            if (!IsLoggedInMember(executionContext.UserContext)) return null;

            var user = await _contentRepository
                .Users()
                .GetCurrent()
                .AsMicroSummary()
                .ExecuteAsync();

            return new MemberSummary()
            {
                UserId = user.UserId,
                Name = user.GetFullName()
            };
        }

        private bool IsLoggedInMember(IUserContext userContext)
        {
            return userContext.UserId.HasValue && userContext.UserArea.UserAreaCode == MemberUserArea.MemberUserAreaCode;
        }
    }
}