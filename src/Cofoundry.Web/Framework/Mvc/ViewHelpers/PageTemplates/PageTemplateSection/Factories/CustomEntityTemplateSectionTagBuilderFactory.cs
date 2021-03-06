﻿using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cofoundry.Web
{
    /// <summary>
    /// Factory that enables ICustomEntityTemplateSectionTagBuilderFactory implementation to be swapped out.
    /// </summary>
    /// <remarks>
    /// The factory is required because the HtmlHelper cannot be injected
    /// </remarks>
    public class CustomEntityTemplateSectionTagBuilderFactory : ICustomEntityTemplateSectionTagBuilderFactory
    {
        private readonly IPageModuleRenderer _moduleRenderer;
        private readonly IPageModuleDataModelTypeFactory _moduleDataModelTypeFactory;
        private readonly IPageModuleTypeFileNameFormatter _moduleTypeFileNameFormatter;

        public CustomEntityTemplateSectionTagBuilderFactory(
            IPageModuleRenderer moduleRenderer,
            IPageModuleDataModelTypeFactory moduleDataModelTypeFactory,
            IPageModuleTypeFileNameFormatter moduleTypeFileNameFormatter)
        {
            _moduleRenderer = moduleRenderer;
            _moduleDataModelTypeFactory = moduleDataModelTypeFactory;
            _moduleTypeFileNameFormatter = moduleTypeFileNameFormatter;
        }

        public ICustomEntityTemplateSectionTagBuilder<TModel> Create<TModel>(
            HtmlHelper htmlHelper,
            ICustomEntityDetailsPageViewModel<TModel> customEntityViewModel, 
            string sectionName
            )
            where TModel : ICustomEntityDetailsDisplayViewModel
        {
            return new CustomEntityTemplateSectionTagBuilder<TModel>(_moduleRenderer, _moduleDataModelTypeFactory, _moduleTypeFileNameFormatter, htmlHelper, customEntityViewModel, sectionName);
        }
    }
}
