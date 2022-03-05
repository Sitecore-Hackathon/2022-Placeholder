import create from '@verndale/core';

const modules = [
  { name: 'cartModule', loader: () => import('./modules/cart/cart') }
];

document.addEventListener('DOMContentLoaded', () => {
  create(modules, 'js/modules');
});
