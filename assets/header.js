let header = `
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link
      href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;700&display=swap"
      rel="stylesheet"
    />
    <link
      href="https://fonts.googleapis.com/css2?family=Space Grotesk:wght@400;500;700&display=swap"
      rel="stylesheet"
    />
    <link
      href="https://fonts.googleapis.com/css2?family=Space Mono:wght@400;500;700&display=swap"
      rel="stylesheet"
    />
    <link rel="apple-touch-icon" sizes="180x180" href="/assets/apple-touch-icon.png">
    <link rel="icon" type="image/png" sizes="32x32" href="/assets/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="/assets/favicon-16x16.png">
    <link rel="manifest" href="/assets/site.webmanifest">
    <link rel="mask-icon" href="/assets/safari-pinned-tab.svg" color="#752efd">
    <link rel="shortcut icon" href="/assets/favicon.ico">
    <meta name="msapplication-TileColor" content="#020143">
    <meta name="msapplication-config" content="/assets/browserconfig.xml">
    <meta name="theme-color" content="#020143">
    <link rel="stylesheet" href="/styles.css" />
    <header class="header__holder center">
      <a class="header center" href="/index.html">
        <img class="branding" src="/assets/aptivi-written-transparent.png"> 
      </a>

      <nav class="nav center">
        <ul class="nav__list center">
          <li class="nav__list-item">
            <a class="link link--nav" href="https://officialaptivi.wordpress.com/2023/03/14/updates-regarding-development-of-our-projects/">Announcement regarding our projects</a>
          </li>
          <li class="nav__list-item">
            <a class="link link--nav" href="https://aptivi.github.io/projects/index.html">Projects</a>
          </li>
          <li class="nav__list-item">
            <a class="link link--nav" href="https://officialaptivi.wordpress.com/contact">Contact</a>
          </li>
          <li class="nav__list-item">
            <a class="link link--nav" href="https://officialaptivi.wordpress.com">Blog</a>
          </li>
        </ul>
      </nav>
    </header>
  </head>
`;
document.getElementById("app-header").innerHTML = header;