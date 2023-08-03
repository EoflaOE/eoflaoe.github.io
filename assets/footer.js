let footer = `
          <div class="about__contact">
            <a
              href="https://github.com/Aptivi"
              aria-label="github"
              class="link link--icon"
            >
              <i aria-hidden="true" class="fab fa-github"></i>
            </a>
            <a
              href="https://discord.gg/MmFBajJmnT"
              aria-label="discord"
              class="link link--icon"
            >
              <i aria-hidden="true" class="fab fa-discord"></i>
            </a>
            <a
              href="https://matrix.to/#/#aptivi-official:matrix.org"
              aria-label="matrix"
              class="link link--icon"
            >
              <i aria-hidden="true" class="fab fa-hubspot"></i>
            </a>
            <a
              href="https://fosstodon.org/@aptivi"
              aria-label="mastodon"
              class="link link--icon"
            >
              <i aria-hidden="true" class="fab fa-mastodon"></i>
            </a>
            <a
              href="https://www.linen.dev/s/aptivi"
              aria-label="linen"
              class="link link--icon"
            >
              <i aria-hidden="true" class="fa fa-comment"></i>
            </a>
            <a class="titleface"> | </a>
            <a class="link footer__link titleface">
              Copyright (c) Aptivi. All rights reserved.
            </a>
          </div>
`;
document.getElementById("app-footer").innerHTML = footer;