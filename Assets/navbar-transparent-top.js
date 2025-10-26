export class NavbarTransparentTop {
  constructor(navbar, options = {}) {
    this.navbar = navbar;
    this.options = Object.assign(options, {
      distance: 0,
    });
    this.initialize();
  }

  addListeners() {
    document.addEventListener("scroll", () => this.toggle());
  }

  toggle() {
    if (document.documentElement.scrollTop > this.options.distance) {
      this.navbar.classList.add("scrolled");
    } else {
      this.navbar.classList.remove("scrolled");
    }
  }

  initialize() {
    this.addListeners();
    this.toggle();
  }

  static create(navbar) {
    if (!navbar.classList.contains("transparent-inited")) {
      new NavbarTransparentTop(navbar);
      navbar.classList.add("transparent-inited");
    }
  }

  static init() {
    document.querySelectorAll(".navbar-transparent-top").forEach((navbar) => {
      NavbarTransparentTop.create(navbar);
    });
  }
}

// Make it available globally for backward compatibility
window.NavbarTransparentTop = NavbarTransparentTop;
