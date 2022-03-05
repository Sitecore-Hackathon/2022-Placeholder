import create from '@verndale/core';

const modules = [
  {
    name: 'sampleModule',
    loader: () => import('./modules/sample/sampleModule')
  }
];

document.addEventListener('DOMContentLoaded', () => {
  create(modules, 'js/modules');
});
