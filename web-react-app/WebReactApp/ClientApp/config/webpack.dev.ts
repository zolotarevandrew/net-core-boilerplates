import webpack from 'webpack';
import common from './webpack.common';
import merge from 'webpack-merge';
import path from 'path';
import paths from './paths';

const bundleFolder = './build/';
const config: webpack.Configuration = {
    mode: 'development',
    devtool: 'inline-source-map',
    entry: [
        'webpack-dev-server/client?/', 
        'webpack/hot/dev-server',
        paths.appIndex
    ],
    output: {
        path: path.resolve(__dirname, bundleFolder),
        pathinfo: true,
        filename: 'bundle.js',
        publicPath: '/'
    },
    devServer: {
        port: 3000,
        host: '0.0.0.0',
        inline: true,
        hot: true,
        contentBase: bundleFolder,
        watchContentBase: true,
        watchOptions: {
            ignored: /node_modules/
        },
        open: true,
        compress: true,
        stats: { colors: true }
    },
    performance: {
        hints: false
    }
};

export default merge(config, common);
