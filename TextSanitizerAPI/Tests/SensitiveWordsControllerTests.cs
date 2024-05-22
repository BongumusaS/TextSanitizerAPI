using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using TextSanitizerAPI.Controllers;
using TextSanitizerAPI.DataContext;
using TextSanitizerAPI.Models;
using Xunit;

namespace TextSanitizerAPI.Tests
{
    public class SensitiveWordsControllerTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<ILogger<SensitiveWordsController>> _mockLogger;
        private readonly SensitiveWordsController _controller;

        public SensitiveWordsControllerTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _mockLogger = new Mock<ILogger<SensitiveWordsController>>();
            _controller = new SensitiveWordsController(_mockContext.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetSensitiveWords_ReturnsOkResult_WithAListOfSensitiveWords()
        {
            // Arrange
            var mockData = new List<SensitiveWord> { new SensitiveWord { Id = 1, Word = "test" } };
            var mockSet = new Mock<DbSet<SensitiveWord>>();
            mockSet.As<IQueryable<SensitiveWord>>().Setup(m => m.Provider).Returns(mockData.AsQueryable().Provider);
            mockSet.As<IQueryable<SensitiveWord>>().Setup(m => m.Expression).Returns(mockData.AsQueryable().Expression);
            mockSet.As<IQueryable<SensitiveWord>>().Setup(m => m.ElementType).Returns(mockData.AsQueryable().ElementType);
            mockSet.As<IQueryable<SensitiveWord>>().Setup(m => m.GetEnumerator()).Returns(mockData.AsQueryable().GetEnumerator());
            _mockContext.Setup(c => c.SensitiveWords).Returns(mockSet.Object);

            // Act
            var result = await _controller.GetSensitiveWords();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<SensitiveWord>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task AddSensitiveWord_ReturnsCreatedAtAction_WithNewSensitiveWord()
        {
            // Arrange
            var newWord = new SensitiveWord { Id = 2, Word = "example" };

            // Act
            var result = await _controller.AddSensitiveWord(newWord);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<SensitiveWord>(createdAtActionResult.Value);


            Assert.Equal(newWord.Id, returnValue.Id);
            Assert.Equal(newWord.Word, returnValue.Word);
        }

        // Add more tests for other controller actions as needed
    }
}
