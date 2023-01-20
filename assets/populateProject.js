let projHolderIntro = `
          <div class="project">
            <div class="project__top">
              <h3 class="titleface">ProjectName</h3>
              <p class="project__description">
                ProjectDescription
              </p>
            </div>

            <div class="project__bottom">
              <ul class="project__stack">
                <li class="project__stack-item">ProjectVersion • ProjectCommitHash</li>
              </ul>
`;

let projHolderLink = `
              <a
                href="https://github.com/Aptivi/ProjectSlug/releases/tag/VersionSlug"
                aria-label="binary download"
                class="link link--icon"
              >
                <i aria-hidden="true" class="fas fa-arrow-down"></i>
              </a>
`;

let projHolderLinkNuGet = `
              <a
                href="https://www.nuget.org/packages/NuGetPackageName/"
                aria-label="nuget"
                class="link link--icon"
              >
                <i aria-hidden="true" class="fa fa-cubes"></i>
              </a>
`;

let projHolderSource = `
              <a
                href="https://github.com/Aptivi/ProjectSlug"
                aria-label="source code"
                class="link link--icon"
              >
                <i aria-hidden="true" class="fab fa-github"></i>
              </a>
`;

let projHolderWiki = `
              <a
                href="https://Aptivi.github.io/ProjectSlug"
                aria-label="wiki"
                class="link link--icon"
              >
                <i aria-hidden="true" class="fas fa-external-link-alt"></i>
              </a>
`;

let projHolderWikiGB = `
              <a
                href="https://aptivi.gitbook.io/ProjectGBSlug"
                aria-label="wiki"
                class="link link--icon"
              >
                <i aria-hidden="true" class="fas fa-external-link-alt"></i>
              </a>
`;

let projHolderOutro = `
            </div>
          </div>
`;

var projVersionNum;
var projVersion;
var projCommitHash;
jQuery.getJSON("https://cdn.jsdelivr.net/gh/Aptivi-Analytics/project-list@main/Projects.json").done(function (data) {
  for (var i = 0; i < data.length; i++) {
    let finalHolder = projHolderIntro;
    
    let slug = data[i].ProjectSlug;
    let sluggb = data[i].ProjectGBSlug;
    let githubApiTagsLink = "https://api.github.com/repos/Aptivi/" + slug + "/tags";
    let wikiLink = "https://Aptivi.github.io/" + slug + "/";
    
    $.ajaxSetup({
      async: false
    });
    
    jQuery.getJSON(githubApiTagsLink).done(function (vdata) {
      window.projVersionNum = vdata[0].name;
      window.projVersion = "Version " + vdata[0].name;
      window.projCommitHash = vdata[0].commit.sha.slice(0,7);
    });
    
    $.ajaxSetup({
      async: true
    });
    
    finalHolder = finalHolder.replace("ProjectName", data[i].ProjectName).replace("ProjectDescription", data[i].Description).replace("ProjectVersion", projVersion).replace("ProjectCommitHash", projCommitHash);
    finalHolder += projHolderLink.replace("ProjectSlug", slug).replace("VersionSlug", window.projVersionNum);
    finalHolder += projHolderSource.replace("ProjectSlug", slug);
    
    for (var j = 0; j < data[i].NuGetPackages.length; j++){
      finalHolder += projHolderLinkNuGet.replace("NuGetPackageName", data[i].NuGetPackages[j]);
    }
    
    finalHolder += projHolderWiki.replace("ProjectSlug", slug);
    finalHolder += projHolderWikiGB.replace("ProjectGBSlug", sluggb);
      
    finalHolder += projHolderOutro;
    
    document.getElementById("projs").innerHTML += finalHolder;
  }
})
