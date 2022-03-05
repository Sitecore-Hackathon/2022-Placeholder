import { Component } from '@verndale/core';
import { Modal } from 'bootstrap';
import axios from 'axios';
import codeflaskMin from 'codeflask';

class Module extends Component {
  setupDefaults() {
    this.dom = {
      $el: this.el,
      $btnGenerate: this.el.querySelector('.cart-module__btn-generate'),
      $btnAtc: this.el.querySelector('.cart-module__atc'),
      $modalSuccess: document.getElementById('modalSuccess'),
      $ModalError: document.getElementById('modalError'),
      $budgeCartIndicator: document.getElementById('badge-cart-indicator'),
      $editor: this.el.querySelector('#cart-module__editor'),
      $codeImage: this.el.querySelector('.cart-module__code'),
      $largeImage: this.el.querySelector('.cart-module__large-image')
    };

    this.endpoint = this.dom.$el.dataset.endpoint || null;
    this.codeEndpoint = this.dom.$el.dataset.codeEndpoint || null;

    this.classes = {
      disabled: 'disabled'
    };

    this.modalSuccess = null;
    this.modalError = null;
    this.flask = null;
    this.language = null;

    this.init();
  } //setupDefaults

  addListeners() {
    const { $btnAtc, $btnGenerate } = this.dom;

    $btnAtc?.addEventListener('click', this.handleAddToCart.bind(this));
    $btnGenerate?.addEventListener('click', this.handleGenerate.bind(this));
  } //addListeners

  init() {
    const { $modalSuccess, $ModalError, $editor } = this.dom;

    if ($modalSuccess) this.modalSuccess = new Modal($modalSuccess);
    if ($ModalError) this.modalError = new Modal($ModalError);

    if ($editor) {
      this.language = $editor.dataset.languaje || 'js';

      this.flask = new codeflaskMin($editor, {
        language: this.language,
        lineNumbers: true,
        defaultTheme: true
      });

      const $codeInput = $editor.querySelector('.codeflask__textarea');
      if (!$codeInput) return;
      $codeInput.setAttribute('maxlength', '280');
      this.flask.updateCode(`console.log("b" + "a" + +"a" + "a");
// 'baNaNa'`);
    }
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

  handleGenerate(e) {
    e.preventDefault();
    if (!this.flask) return;

    const code = this.flask.getCode();
    if (!code) return;

    const { $btnGenerate, $codeImage, $largeImage } = this.dom;

    $btnGenerate.classList.add(this.classes.disabled);

    axios({
      method: 'get',
      url: this.codeEndpoint,
      params: {
        backgroundColor: 'rgba(255, 255, 255, 1)',
        code: encodeURI(code),
        theme: 'dracula',
        dropShadow: false,
        paddingHorizontal: '0px',
        paddingVertical: '0px',
        widthAdjustment: false,
        lineNumbers: true,
        fontSize: '20px'
      },
      responseType: 'arraybuffer'
    })
      .then(response => {
        const image = response.data || null;

        if (image) {
          $codeImage.innerHTML = '';
          const $imageHtml = document.createElement('img');

          const blob = new Blob([image], {
            type: response.headers['content-type']
          });
          const imageUrl = URL.createObjectURL(blob);
          $imageHtml.setAttribute('src', imageUrl);
          $codeImage.appendChild($imageHtml);
        } else {
          if (this.modalError) this.modalError.show();
        }
      })
      .catch(error => {
        if (this.modalError) this.modalError.show();
      })
      .finally(() => {
        $btnGenerate.classList.remove(this.classes.disabled);
        $largeImage.scrollIntoView({ behavior: 'smooth' });
      });
  } //handleGenerate

  updateCartIndicator(items) {
    const { $budgeCartIndicator } = this.dom;
    if ($budgeCartIndicator) $budgeCartIndicator.textContent = items || 0;
  } //updateCartIndicator
}

export default Module;
