;(function () {
  function changeTabs(target) {
    const parent = target.parentNode;
    const grandparent = parent.parentNode;

    // Remove all current selected tabs
    parent
      .querySelectorAll('[aria-selected="true"]')
      .forEach(t => t.setAttribute('aria-selected', false));

    // Set this tab as selected
    target.setAttribute('aria-selected', true);

    // Hide all tab panels
    grandparent
      .querySelectorAll('[role="tabpanel"]')
      .forEach(p => p.setAttribute('hidden', true));

    // Show the selected panel
    const activeTab = grandparent.parentNode
      .querySelector('#' + target.getAttribute('aria-controls'));
    if (!activeTab) {
      return;
    }
    activeTab.removeAttribute('hidden');

    // work around Safari layout bugs: force a re-flow
    const iframes = activeTab.querySelectorAll('iframe')
    for (const iframe of iframes) {
      iframe.style['padding-right'] = '1px';
      iframe.clientWidth;
      iframe.style['padding-right'] = null;
    }
  }

  function tabClick(event) {
    changeTabs(event.target);
  }

  // Add a click event handler to each tab
  const tabs = document.querySelectorAll('[role="tab"]');
  tabs.forEach(tab => tab.addEventListener('click', tabClick));

  function onHashChange() {
    const hash = window.location.hash;
    if (!hash) {
      return;
    }
    let element = document.getElementById(hash.substring(1));
    if (!element) {
      return;
    }

    // find the tab section
    let tabName = null;
    while (!tabName && element.parentNode && !element.classList.contains('md-content')) {
      if (element.tagName === 'SECTION' && element.getAttribute('role') === 'tabpanel') {
        tabName = element.getAttribute('id');
      }
      element = element.parentNode;
    }
    if (!tabName) {
      return;
    }

    // get the tab, select
    var tab = document.querySelector('[role="tab"][aria-controls="' + tabName + '"]')
    if (tab) {
      changeTabs(tab);
    }
  }

  window.addEventListener('hashchange', onHashChange);
  onHashChange();
})();
