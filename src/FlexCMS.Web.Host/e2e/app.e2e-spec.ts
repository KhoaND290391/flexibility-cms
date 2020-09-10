import { FlexCMSTemplatePage } from './app.po';

describe('FlexCMS App', function() {
  let page: FlexCMSTemplatePage;

  beforeEach(() => {
    page = new FlexCMSTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
