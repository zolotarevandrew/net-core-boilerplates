import webpack from 'webpack';
import WebpackDevServer from 'webpack-dev-server';
import config from '../config/webpack.dev';
import open from 'open';

process.env.NODE_ENV = 'development';
console.log('Try start the dev web server...');

const getConfig = () => config && config.devServer;
const getPort = () => config && config.devServer && config.devServer.port || 3000;
const getHost = () => config && config.devServer && config.devServer.host || 'localhost';
const isOpenBrowser = () => config && config.devServer && config.devServer.open;

const server = new WebpackDevServer(webpack(config), getConfig());

server.listen(getPort(), getHost(), (err) => {
  if (err) {
    console.log(err);
  }
  if (isOpenBrowser()) {
    open(`http://localhost:${getPort()}`);
  }
  console.log('WebpackDevServer listening at localhost:', getPort());
});
