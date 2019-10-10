import webpack from 'webpack';
import config from '../config/webpack.prod';
import formatWebpackMessages from 'react-dev-utils/formatWebpackMessages';

process.env.NODE_ENV = 'production';

const runBuild = () => {
    console.log('Creating an optimized production build...');

    let compiler = webpack(config);
    compiler.run((err, stats) => {
        if (err) {
            throw (err);
        }
        const messages = formatWebpackMessages(stats.toJson({}, true));
        if (messages.errors.length) {
            throw (new Error(messages.errors.join('\n\n')));
        }
        if (process.env.CI && messages.warnings.length) {
            console.log(
                '\nTreating warnings as errors because process.env.CI = true.\n' +
                'Most CI servers set it automatically.\n'
            );
            throw (new Error(messages.warnings.join('\n\n')));
        }
        console.log('Build Success');
    });
};

try {
    runBuild();
} catch (err) {
    console.log(err);
}
