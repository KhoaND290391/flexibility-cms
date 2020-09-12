using FlexCMS.Contents;
using FlexCMS.EntityFrameworkCore;
using FlexCMS.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexCMS.Tests.Data
{
    public class TestDataBuilder
    {
        public const string TestContentPageName = "Test Content PageName";
        public const string TestContentPageContent = "Test Content PageContent";

        private readonly FlexCMSDbContext _context;

        public TestDataBuilder(FlexCMSDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateTestContent();
        }

        private void CreateTestContent()
        {
            _context.Contents.Add(Content.CreateContent(0, TestContentPageName, TestContentPageContent,0));
            _context.SaveChanges();
        }
    }
}
