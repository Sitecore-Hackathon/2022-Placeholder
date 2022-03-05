import { Component } from '@verndale/core';

class Module extends Component {
  setupDefaults() {
    this.dom = {
      el: this.el
    };

    this.init();
  } //setupDefaults

  addListeners() {} //addListeners

  init() {
    console.log('sampleModule', this.dom);
  } //init
}

export default Module;
