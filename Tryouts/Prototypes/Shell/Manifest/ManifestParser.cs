﻿// /*
//  * Morgan Stanley makes this available to you under the Apache License,
//  * Version 2.0 (the "License"). You may obtain a copy of the License at
//  *
//  *      http://www.apache.org/licenses/LICENSE-2.0.
//  *
//  * See the NOTICE file distributed with this work for additional information
//  * regarding copyright ownership. Unless required by applicable law or agreed
//  * to in writing, software distributed under the License is distributed on an
//  * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
//  * or implied. See the License for the specific language governing permissions
//  * and limitations under the License.
//  */

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;

namespace Manifest
{
    internal class ManifestParser
    {
        internal ManifestModel Manifest { get; set; }

        public ManifestParser()
        {
            OpenManifestFile("./Manifest/exampleManifest.json");
        }

        public async void OpenManifestFile(string manifestFile)
        {
             using (FileStream stream = File.Open(manifestFile, FileMode.Open))
             {
                 Manifest = JsonSerializer.Deserialize<ManifestModel>(stream, ManifestModel.JsonSerializerOptions);

                 stream.Close();
             }
        }
    }
}
