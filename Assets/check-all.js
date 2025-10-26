class Datatable {
  constructor() {
    this.init();
  }

  init() {
    this.bindEvents();
  }

  bindEvents() {
    // Check/Uncheck all functionality
    document.addEventListener("change", (e) => {
      if (e.target.classList.contains("check-all")) {
        this.toggleAllCheckboxes(e.target.checked);
      }

      if (e.target.classList.contains("check-item")) {
        // this.updateCheckAllState();
        this.toggleBulkActions();
      }
    });

    // Apply bulk action
    document.addEventListener("click", (e) => {
      if (
        e.target.id === "applyBulkAction" ||
        e.target.closest("#applyBulkAction")
      ) {
        this.applyBulkAction();
      }
    });

    // Initialize bulk actions visibility
    this.toggleBulkActions();
  }

  toggleAllCheckboxes(checked) {
    const checkItems = document.querySelectorAll(".check-item");
    checkItems.forEach((checkbox) => {
      checkbox.checked = checked;
    });
    this.toggleBulkActions();
  }

  updateCheckAllState() {
    const checkAll = document.querySelector(".check-all");
    const checkItems = document.querySelectorAll(".check-item");
    const checkedItems = document.querySelectorAll(".check-item:checked");

    checkAll.checked = checkedItems.length === checkItems.length;
    checkAll.indeterminate =
      checkedItems.length > 0 && checkedItems.length < checkItems.length;
  }

  toggleBulkActions() {
    const checkedItems = document.querySelectorAll(".check-item:checked");
    const bulkActions = document.querySelectorAll(
      ".bulk-action, .bulk-action-btn"
    );

    if (checkedItems.length > 0) {
      bulkActions.forEach((element) => {
        element.style.display = "inline-block";
      });
    } else {
      bulkActions.forEach((element) => {
        element.style.display = "none";
      });
    }
  }

  getSelectedItems() {
    const checkedItems = document.querySelectorAll(".check-item:checked");
    return Array.from(checkedItems).map((checkbox) => checkbox.value);
  }

  applyBulkAction() {
    const bulkAction = document.getElementById("bulkAction");
    const selectedItems = this.getSelectedItems();
    const bulkForm = document.getElementById("bulkForm");

    if (!bulkAction.value) {
      alert("يرجى اختيار إجراء");
      return;
    }

    if (selectedItems.length === 0) {
      alert("يرجى اختيار مستخدم واحد على الأقل");
      return;
    }

    if (bulkAction.value === "delete") {
      if (confirm(`هل تريد حذف ${selectedItems.length} مستخدم؟`)) {
        // Ensure the form has the correct action
        bulkForm.action =
          bulkForm.action || window.location.href.replace("/Index", "/Apply");
        bulkForm.submit();
      }
    }
  }
}

// Initialize when DOM is loaded
document.addEventListener("DOMContentLoaded", () => {
  new Datatable();
});

// Export for use in other modules if needed
if (typeof module !== "undefined" && module.exports) {
  module.exports = Datatable;
}
