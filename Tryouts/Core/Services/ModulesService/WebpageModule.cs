﻿/// ********************************************************************************************************
///
/// Morgan Stanley makes this available to you under the Apache License, Version 2.0 (the "License").
/// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0.
/// See the NOTICE file distributed with this work for additional information regarding copyright ownership.
/// Unless required by applicable law or agreed to in writing, software distributed under the License
/// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and limitations under the License.
/// 
/// ********************************************************************************************************

using MorganStanley.ComposeUI.Tryouts.Core.Abstractions.Modules;

namespace MorganStanley.ComposeUI.Tryouts.Core.Services.ModulesService;

internal class WebpageModule : ModuleBase
{
    public WebpageModule(string name, Guid instanceId, string url) : base(name, instanceId)
    {
        _url = url;
    }

    private string _url;

    public override ProcessInfo ProcessInfo => new ProcessInfo(
        name: Name,
        instanceId: InstanceId,
        uiType: UIType.Web,
        uiHint: _url
        );

    public override Task Initialize()
    {
        return Task.CompletedTask;
    }

    public override Task Launch()
    {
        _lifecycleEvents.OnNext(LifecycleEvent.Started(new ProcessInfo(Name, InstanceId, UIType.Web, _url)));
        return Task.CompletedTask;
    }

    public override Task Teardown()
    {
        _lifecycleEvents.OnNext(LifecycleEvent.Stopped(new ProcessInfo(Name, InstanceId, UIType.Web, _url)));
        return Task.CompletedTask;
    }
}
