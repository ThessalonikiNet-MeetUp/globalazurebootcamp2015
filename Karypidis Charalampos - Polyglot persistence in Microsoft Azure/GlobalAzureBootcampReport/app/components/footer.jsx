var React = require('react');
var ReactBootstrap = require('reactBootstrap');

var Footer = React.createClass({
	render() {
		return (		
			<div>
				Created by <a href="http://xabikos.com" target="_blank">xabikos</a><br/>
				Hosted by <a href="http://azure.microsoft.com/en-us/" target="_blank">Microsoft Azure</a><br/>
				Powered by <a href="https://facebook.github.io/react/" target="_blank">ReactJS</a> and <a href="http://reactjs.net/" target="_blank">ReactJS.NET</a><br/>
				Source code on <a href="https://github.com/xabikos/globalazurebootcampreport" target="_blank">Github</a><br/>
			</div>
		);
	}
});

module.exports = Footer;