﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Dependency;

namespace PolyStone.App
{
    public class LocalizationService:ApplicationService,ILocalizationService,ISingletonDependency
    {
        public string L(string name, params object[] args)
        {
            return base.L(name, args);
        }
    }
}