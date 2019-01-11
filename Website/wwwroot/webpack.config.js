const path = require('path')
const webpack = require('webpack')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const devMode = process.env.NODE_ENV !== 'production';

module.exports = {
  entry: './src/js/index.js',
  output: {
    path: path.resolve(__dirname, './dist'),
    publicPath: '/dist/',
    filename: 'main.js'
  },
  module: {
    rules: [{
        test: /\.css$/,
        loader: 'style-loader!css-loader'
      },
      { 
          test: /\.scss$/,
            use: [
              devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
              'css-loader',
              'sass-loader'
        ]
      },
      {
        test: /\.js$/,
        loader: 'babel-loader',
        exclude: /node_modules/
      },
      {
        test: /\.(png|jpg|gif|svg)$/,
        loader: 'file-loader',
        options: {
          name: '[name].[ext]?[hash]'
        }
      }
    ]
  },
  resolve: {

  },
  // node: {
  //   fs: 'empty'
  // },
  devServer: {
    historyApiFallback: true,
    noInfo: true,
    overlay: true,
    proxy: {
      '*': {
        target: 'https://localhost:5003',
        changeOrigin: true,
        secure: false
      }
    }
  },
  performance: {
    hints: false
  },
  devtool: '#eval-source-map'
}

if (!devMode) {

  module.exports.devtool = '#source-map'
  module.exports.plugins = (module.exports.plugins || []).concat([
    new MiniCssExtractPlugin({
      // Options similar to the same options in webpackOptions.output
      // both options are optional
      filename: "[name].css",
      chunkFilename: "[id].css"
    }),
    new webpack.LoaderOptionsPlugin({
      minimize: true
    })
  ])
} else {
  //dev or other...
  module.exports.plugins = (module.exports.plugins || []).concat([
    new webpack.NamedModulesPlugin()
  ]);
}
