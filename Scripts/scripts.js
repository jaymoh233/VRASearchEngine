const sidebarToggleBtns = document.querySelectorAll(".sidebar-toggle");
const sidebar = document.querySelector(".sidebar");
const searchForm = document.querySelector(".search-form");
const themeToggleBtn = document.querySelector(".theme-toggle");
const themeIcon = themeToggleBtn.querySelector(".theme-icon");
const menuLinks = document.querySelectorAll(".menu-link");
// Updates the theme icon based on current theme and sidebar state
const updateThemeIcon = () => {
    const isDark = document.body.classList.contains("dark-theme");
    themeIcon.textContent = sidebar.classList.contains("collapsed") ? (isDark ? "light_mode" : "dark_mode") : "dark_mode";
};
// Apply dark theme if saved or system prefers, then update icon
const savedTheme = localStorage.getItem("theme");
const systemPrefersDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
const shouldUseDarkTheme = savedTheme === "dark" || (!savedTheme && systemPrefersDark);
document.body.classList.toggle("dark-theme", shouldUseDarkTheme);
updateThemeIcon();
// Toggle between themes on theme button click
themeToggleBtn.addEventListener("click", () => {
    const isDark = document.body.classList.toggle("dark-theme");
    localStorage.setItem("theme", isDark ? "dark" : "light");
    updateThemeIcon();
});
// Toggle sidebar collapsed state on buttons click
sidebarToggleBtns.forEach((btn) => {
    btn.addEventListener("click", () => {
        sidebar.classList.toggle("collapsed");
        updateThemeIcon();
    });
});
// Expand the sidebar when the search form is clicked
searchForm.addEventListener("click", () => {
    if (sidebar.classList.contains("collapsed")) {
        sidebar.classList.remove("collapsed");
        searchForm.querySelector("input").focus();
    }
});
// Expand sidebar by default on large screens
if (window.innerWidth > 768) sidebar.classList.remove("collapsed");


// dropdown toggle for parent links
document.querySelectorAll(".menu-item.has-dropdown > .menu-link").forEach(link => {
    link.addEventListener("click", function (e) {
        e.preventDefault();
        const parent = this.closest(".menu-item");

        // optionally close other open dropdowns (uncomment if you want single-open behavior)
        // document.querySelectorAll(".menu-item.has-dropdown.open").forEach(item => {
        //   if (item !== parent) item.classList.remove("open");
        // });

        parent.classList.toggle("open");
    });
});

// manage submenu link active state (keeps UI consistent)
document.querySelectorAll(".submenu-link").forEach(s => {
    s.addEventListener("click", function () {
        // remove .active from all submenu links
        document.querySelectorAll(".submenu-link").forEach(x => x.classList.remove("active"));
        // remove .active from top-level links if needed
        document.querySelectorAll(".menu-link").forEach(x => x.classList.remove("active"));

        this.classList.add("active");

        // optionally close sidebar on mobile or do navigation naturally
        // window.location = this.href; // leave default if link is real
    });
});
