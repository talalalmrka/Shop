import { DarkModeManager } from "./dark-mode-manager.js";
import { RtlToggler } from "./rtl-toggler.js";
import { Dropdown } from "./dropdown.js";
import { NavBar } from "./navbar.js";
import { Offcanvas } from "./offcanvas.js";
import { Tooltip } from "./tooltip.js";
import { Modal } from "./modal.js";
import { ButtonBackTop } from "./button-backtop.js";
import { PasswordToggle } from "./password-toggle.js";
import { Tabs } from "./tabs.js";
import Toast from "./toast.js";

export const initFadgramUI = () => {
  DarkModeManager.init();
  RtlToggler.init();
  ButtonBackTop.init();
  Dropdown.init();
  NavBar.init();
  Offcanvas.init();
  Tooltip.init();
  Modal.init();
  PasswordToggle.init();
  Tabs.init();
  window.Toast = Toast;
};
document.addEventListener("DOMContentLoaded", () => {
  initFadgramUI();
});
