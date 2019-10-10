import webpack from 'webpack';
import common from './webpack.common';
import paths from './paths';
import merge from 'webpack-merge';
import path from 'path';

const bundleFolder = '../build/';
const config: webpack.Configuration = {
    mode: 'production',
    devtool: 'source-map',
    entry: [paths.appIndex],
    output: {
        path: path.resolve(__dirname, bundleFolder),
        pathinfo: true,
        filename: 'bundle.js',
        publicPath: ''
    },
    performance: {
        hints: false
    }
};

export default merge(config, common);
