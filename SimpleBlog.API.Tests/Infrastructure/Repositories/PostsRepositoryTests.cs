using SimpleBlog.API.Infrastructure;
using FakeItEasy;
using Xunit;
using SimpleBlog.API.Controllers;
using SimpleBlog.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleBlog.API.Tests
{
    public class PostsRepositoryTests
    {
        protected IPostsRepository FakePostsRepository;
        protected PostsController FakePostsController;

        [Fact]
        public async Task PostsRepository_CallsClient_And_ReturnsCorrectType_WhenGettingPosts()
        {
            //  Arrange
            FakePostsRepository = A.Fake<IPostsRepository>();
            FakePostsController = new PostsController(FakePostsRepository);

            //  Act
            var fakeModel = await FakePostsController.Get();

            //  Assert
            A.CallTo(() => FakePostsRepository.GetN<Post>(100)).MustHaveHappenedOnceExactly();
            Assert.IsType<ActionResult<string>>(fakeModel);
        }
    }
}
