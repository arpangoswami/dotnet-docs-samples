/*
 * Copyright 2024 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.Cloud.SecretManager.V1;
using Xunit;

[Collection(nameof(RegionalSecretManagerFixture))]
public class UpdateRegionalSecretTests
{
    private readonly RegionalSecretManagerFixture _fixture;
    private readonly UpdateRegionalSecretSample _sample;

    public UpdateRegionalSecretTests(RegionalSecretManagerFixture fixture)
    {
        _fixture = fixture;
        _sample = new UpdateRegionalSecretSample();
    }

    [Fact]
    public void UpdatesRegionalSecrets()
    {
        // Get the secret name.
        SecretName secretName = _fixture.CreateSecret(_fixture.RandomId()).SecretName;

        // Run the code sample.
        Secret result = _sample.UpdateRegionalSecret(
          projectId: secretName.ProjectId,
          locationId: secretName.LocationId,
          secretId: secretName.SecretId
        );

        // Assert that the secret labels was correctly updated.
        Assert.Equal("rocks", result.Labels["secretmanager"]);

        // Clean the created secret.
        _fixture.DeleteSecret(secretName);
    }
}
