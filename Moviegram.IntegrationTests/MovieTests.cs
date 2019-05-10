using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moviegram.Models.ResponseModels;
using Xunit;

namespace Moviegram.IntegrationTests
{

    public class MovieTests
    {
        private readonly HttpClient _httpClient;

        public MovieTests()
        {
            var virtualServer = new VirtualServer();
            _httpClient = virtualServer.GetClient();

        }

        [Fact]
        public async Task Ping()
        {
            var response = await _httpClient.GetAsync("/api/Home/Ping");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("pong", result);
        }

        [Fact]
        public async Task Can_List_Movies()
        {
            var response = await _httpClient.GetAsync("/api/Movie/Movies");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<MoviesListResponseModel>();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(result.Movies);
            Assert.Equal(20, result.Movies.Count);
        }

        [Fact]
        public async Task Can_List_All_Movies()
        {
            var totalCount = 0;
            for (int i = 0; i < 15; i++)
            {
                var response = await _httpClient.GetAsync($"/api/Movie/Movies?CursorIndex={i}&CursorPageSize=10");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<MoviesListResponseModel>();
                totalCount += result.Movies.Count;
            }
            Assert.Equal(100, totalCount);
        }

        [Fact]
        public async Task Is_Cursor_Working_Correctly_With_MovieList()
        {
            for (var i = 0; i < 10; i++)
            {
                var response = await _httpClient.GetAsync($"/api/Movie/Movies?CursorIndex={i}&CursorPageSize=10");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<MoviesListResponseModel>();
                Assert.Equal(10, result.Movies.Count);
            }
        }

    }
}
