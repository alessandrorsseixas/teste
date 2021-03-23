 const proxy = [
  {
    context: '/api',
    target: 'http://localhost:55262',
    pathRewrite: {'^/api' : ''}
  }
];
module.exports = proxy;