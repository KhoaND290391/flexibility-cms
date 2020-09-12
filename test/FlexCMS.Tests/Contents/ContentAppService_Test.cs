using Abp.Domain.Uow;
using Abp.UI;
using FlexCMS.Contents;
using FlexCMS.Contents.Dto;
using FlexCMS.EntityFrameworkCore;
using FlexCMS.Tests.Data;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FlexCMS.Tests.Contents
{
    public class ContentAppService_Test : FlexCMSTestBase
    {
        private readonly IContentAppService _contentAppService;
        public ContentAppService_Test()
        {
            _contentAppService = Resolve<IContentAppService>();
        }
        [Fact]
        public async Task Should_Get_Empty_At_Begin_GetAll()
        {
            var output =  await _contentAppService.GetAll();
            output.Items.Count.ShouldBe(0);
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Not_Provide_Content_Id_GetCMSContent()
        {
            await Assert.ThrowsAsync<UserFriendlyException>(() => _contentAppService.GetCMSContent(0));
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Not_Exist_Content_Id_GetCMSContent()
        {
            await Assert.ThrowsAsync<UserFriendlyException>(() => _contentAppService.GetCMSContent(99));
        }

        [Fact]
        public async Task Should_Insert_Content_InsertOrUpdateCMSContent()
        {
            //Arrange
            var newPageName = Guid.NewGuid().ToString();

            //Act
            await _contentAppService.InsertOrUpdateCMSContent(new CreateOrUpdateContentDto() 
            { 
                Id = 0, 
                PageContent = "A PageContent", 
                PageName = newPageName
            });

            //Assert
            UsingDbContext(context =>
            {
                context.Contents.FirstOrDefault(e => e.PageName == newPageName).ShouldNotBe(null);
            });
        }

        [Fact]
        public async Task Should_Not_Get_Empty_Contents_GetAll()
        {
            UsingDbContext(ctx => new TestDataBuilder(ctx).Build());
            var output = await _contentAppService.GetAll();
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Not_Null_GetCMSContent()
        {
            UsingDbContext(ctx => new TestDataBuilder(ctx).Build());
            var output = await _contentAppService.GetCMSContent(1);
            output.ShouldNotBe(null);
        }

        [Fact]
        public async Task Should_Update_Content_InsertOrUpdateCMSContent()
        {
            //Arrange
            UsingDbContext(ctx => new TestDataBuilder(ctx).Build());
            var newPageName = Guid.NewGuid().ToString();
            var contentId = GetTestContent().Id;

            //Act
            await _contentAppService.InsertOrUpdateCMSContent(new CreateOrUpdateContentDto()
            {
                Id = contentId,
                PageContent = "A PageContent",
                PageName = newPageName
            });

            //Assert


            UsingDbContext(context =>
            {
                context.Contents.FirstOrDefault(e => e.PageName == newPageName && e.Id == contentId).ShouldNotBe(null);
            });
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Not_Exist_Content_Id_Except_Zero_InsertOrUpdateCMSContent()
        {
            //Arrange
            UsingDbContext(ctx => new TestDataBuilder(ctx).Build());
            var newPageName = Guid.NewGuid().ToString();
            var contentId = 99;

            //Act
            //await _contentAppService.InsertOrUpdateCMSContent(new CreateOrUpdateContentDto()
            //{
            //    Id = contentId,
            //    PageContent = "A PageContent",
            //    PageName = newPageName
            //});

            //Assert
            await Assert.ThrowsAsync<AbpDbConcurrencyException> (() => _contentAppService.InsertOrUpdateCMSContent(new CreateOrUpdateContentDto()
            {
                Id = contentId,
                PageContent = "A PageContent",
                PageName = newPageName
            }));
        }

        private Content GetTestContent()
        {
            return UsingDbContext(context => GetTestContent(context));
        }

        private static Content GetTestContent(FlexCMSDbContext context)
        {
            return context.Contents.Single(e => e.PageName == TestDataBuilder.TestContentPageName);
        }
    }
}
