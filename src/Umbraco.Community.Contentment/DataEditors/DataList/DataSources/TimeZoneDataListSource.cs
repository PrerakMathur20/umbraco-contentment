﻿/* Copyright © 2019 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.Linq;
#if NET472
using Umbraco.Core.PropertyEditors;
#else
using Umbraco.Cms.Core.PropertyEditors;
#endif

namespace Umbraco.Community.Contentment.DataEditors
{
    public sealed class TimeZoneDataListSource : IDataListSource, IDataSourceValueConverter
    {
        public string Name => ".NET Time Zones (UTC)";

        public string Description => "All the time zones available in the .NET Framework.";

        public string Icon => "icon-globe";

        public string Group => Constants.Conventions.DataSourceGroups.DotNet;

        public IEnumerable<ConfigurationField> Fields => default;

        public Dictionary<string, object> DefaultValues => default;

        public OverlaySize OverlaySize => OverlaySize.Small;

        public IEnumerable<DataListItem> GetItems(Dictionary<string, object> config)
        {
            return TimeZoneInfo
                .GetSystemTimeZones()
                .Select(x => new DataListItem
                {
                    Name = x.DisplayName,
                    Value = x.Id
                });
        }

        public Type GetValueType(Dictionary<string, object> config) => typeof(TimeZoneInfo);

        public object ConvertValue(Type type, string value) => TimeZoneInfo.FindSystemTimeZoneById(value);
    }
}
