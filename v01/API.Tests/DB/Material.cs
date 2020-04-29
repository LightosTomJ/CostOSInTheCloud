using API.Controllers.DB.Local;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.DB
{
    public class Material
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessionsAsync()
        {
            // Arrange
            // Mock object
            var list = new List<Models.DB.Local.Material>();
            var material = new Models.DB.Local.Material() { };
            list.Add(material);
            //Mock context and DbSet
            var mockContext = new Mock<LocalContext>();
            var mockSet = new Mock<DbSet<Models.DB.Local.Material>>();

            var queryable = list.AsQueryable();
            mockSet.As<IQueryable<Models.DB.Local.Material>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Models.DB.Local.Material>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Models.DB.Local.Material>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Models.DB.Local.Material>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            mockContext.Setup(db => db.Material).Returns(mockSet.Object);
            var f = mockSet.Object.FirstOrDefault();
            //Mock controller
            var controller = new MaterialController();

            // Act
            var result = await controller.GetMaterials();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IList<Material>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);
        }

        //[Fact]
        //public void Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        //{
        //    // Arrange
        //    List<Models.DB.Local.Material> lMaterials = new List<Models.DB.Local.Material>();
        //    var material = new Models.DB.Local.Material() { };
        //    lMaterials.Add(material);
        //    var mockContext = new Mock<localContext>();
        //    var mockMaterialDbSet = new Mock<DbSet<Models.DB.Local.Material>>();
        //    mockContext.Setup(db => db.Material).Returns(mockMaterialDbSet.Object);

        //    var controller = new MaterialController(mockContext.Object);

        //    // Act
        //    var result = controller.GetMaterials();

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsAssignableFrom<IList<Material>>(
        //        viewResult.ViewData.Model);
        //    Assert.Equal(2, model.Count);
        //}
    }
}
