// Import CSS
import "./app.css";
import "./lib/index.js";
// Import JavaScript modules
import "./navbar-transparent-top.js";
import "./check-all.js";

// Initialize the application
document.addEventListener("DOMContentLoaded", () => {
  console.log("Store application initialized");

  // Initialize navbar if available
  if (window.NavbarTransparentTop) {
    window.NavbarTransparentTop.init();
  }
});
