using static System.Net.HttpStatusCode;
using static Xunit.Assert;

namespace AspireAppDemo.Tests;

public class WebTests
{
    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        // Arrange
        await using var app = await (await DistributedApplicationTestingBuilder.CreateAsync<Projects.AspireAppDemo_AppHost>()).BuildAsync();
        await app.StartAsync();

        // Act
        var response = await app.CreateHttpClient("webfrontend").GetAsync("/");

        // Assert
        Equal(OK, response.StatusCode);
    }
}
