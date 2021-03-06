﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain.CQS;
using Cofoundry.Domain.Data;
using AutoMapper.QueryableExtensions;

namespace Cofoundry.Domain
{
    public class GetAllPageGroupSummaryQueryHandler 
        : IQueryHandler<GetAllQuery<PageGroupSummary>, IEnumerable<PageGroupSummary>>
        , IPermissionRestrictedQueryHandler<GetAllQuery<PageGroupSummary>, IEnumerable<PageGroupSummary>>
    {
        private readonly CofoundryDbContext _dbContext;

        public GetAllPageGroupSummaryQueryHandler(
            CofoundryDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PageGroupSummary> Execute(GetAllQuery<PageGroupSummary> query, IExecutionContext executionContext)
        {
            var results = _dbContext
                          .PageGroups
                          .AsNoTracking()
                          .Where(g => !g.IsDeleted)
                          .OrderBy(m => m.GroupName)
                          .ProjectTo<PageGroupSummary>()
                          .ToList();

            return results;
        }

        #region Permission

        public IEnumerable<IPermissionApplication> GetPermissions(GetAllQuery<PageGroupSummary> query)
        {
            yield return new PageReadPermission();
        }

        #endregion
    }
}
