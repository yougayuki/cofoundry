﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;

namespace Cofoundry.Domain.Bootstrap
{
    public class PageTemplateDependencyRegistration : IDependencyRegistration
    {
        public void Register(IContainerRegister container)
        {
            container
                .RegisterType<PageTemplateSectionMapper, PageTemplateSectionMapper>()
                .RegisterType<IPageTemplateCustomEntityTypeMapper, PageTemplateCustomEntityTypeMapper>()
                .RegisterType<PageTemplateCustomEntityTypeValueResolver, PageTemplateCustomEntityTypeValueResolver>()
                ;
        }
    }
}
