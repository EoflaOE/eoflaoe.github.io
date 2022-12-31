let holder = `
          <div class="project">
            <div class="project__top">
              <h3 class="titleface">ProjectName</h3>
              <a class="statok statok--outline">StatusText</a>
              <p class="project__description">
                HealthDesc
              </p>
            </div>
            
            <div class="project__bottom">
              <ul class="project__stack">
                <li class="project__stack-item">IncidentDate • AffectedVersion</li>
              </ul>
            </div>
          </div>
`;

jQuery.getJSON("https://cdn.jsdelivr.net/gh/Aptivi-Analytics/project-health@main/Health.json").done(function (data) {
  for (var i = 0; i < data.length; i++) {
    let finalHolder = holder;
    if (data[i].IsDegraded)
      finalHolder = finalHolder.replace("statok", "statfail").replace("statok--outline", "statfail--outline").replace("StatusText", "Degraded");
    document.getElementById("dashboard").innerHTML += 
      finalHolder.replace("ProjectName", data[i].ProjectName).replace("HealthDesc", data[i].Description).replace("IncidentDate", data[i].DiscoveredDate).replace("AffectedVersion", data[i].AffectedVersion).replace("StatusText", "Fully operational");
  }
})
