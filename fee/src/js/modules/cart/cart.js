import { Component } from '@verndale/core';
import { Modal } from 'bootstrap';
import axios from 'axios';

class Module extends Component {
  setupDefaults() {
    this.dom = {
      $el: this.el,
      $btnAtc: this.el.querySelector('.cart-module__atc'),
      $modalSuccess: document.getElementById('modalSuccess'),
      $ModalError: document.getElementById('modalError'),
      $budgeCartIndicator: document.getElementById('badge-cart-indicator')
    };

    this.endpoint = this.dom.$el.dataset.endpoint || null;

    this.classes = {
      disabled: 'disabled'
    };

    this.modalSuccess = null;
    this.modalError = null;

    this.init();
  } //setupDefaults

  addListeners() {
    const { $btnAtc } = this.dom;

    $btnAtc?.addEventListener('click', this.handleAddToCart.bind(this));
  } //addListeners

  init() {
    const { $modalSuccess, $ModalError } = this.dom;

    if ($modalSuccess) this.modalSuccess = new Modal($modalSuccess);
    if ($ModalError) this.modalError = new Modal($ModalError);
  } //init

  handleAddToCart(e) {
    e.preventDefault();

    const { $btnAtc } = this.dom;
    $btnAtc.classList.add(this.classes.disabled);

    const data = { productId: 'sample' };

    axios({
      method: 'post',
      url: this.endpoint,
      data
    })
      .then(response => {
        const { success, items } = response?.data || {};
        if (success) {
          if (this.modalSuccess) this.modalSuccess.show();
          this.updateCartIndicator(items);
        } else {
          if (this.modalError) this.modalError.show();
        }
      })
      .catch(error => {
        if (this.modalError) this.modalError.show();
      })
      .finally(() => {
        $btnAtc.classList.remove(this.classes.disabled);
      });
  } //handleAddToCart

  updateCartIndicator(items) {
    const { $budgeCartIndicator } = this.dom;
    if ($budgeCartIndicator) $budgeCartIndicator.textContent = items || 0;
  } //updateCartIndicator
}

export default Module;
