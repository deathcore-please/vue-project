module.exports = {
    pages: {
        index: {
            entry: 'src/main.js'
        }
    },
  configureWebpack: {
    devtool: 'source-map'
  },
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:5000',
        changeOrigin: true
      }
    }
  }
}
