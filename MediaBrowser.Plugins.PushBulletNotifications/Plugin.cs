﻿using System;
using System.Collections.Generic;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Plugins.PushBulletNotifications.Configuration;

namespace MediaBrowser.Plugins.PushBulletNotifications
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public override string Name
        {
            get { return "PushBullet Notifications"; }
        }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = Name,
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.config.html"
                }
            };
        }

        public override string Description
        {
            get
            {
                return "Sends notifications via PushBullet Service.";
            }
        }

        private Guid _id = new Guid("de228f12-e43e-4bd9-9fc0-2830819c3b92");
        public override Guid Id
        {
            get { return _id; }
        }

        public static Plugin Instance { get; private set; }
    }
}
