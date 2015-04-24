var React = require('react');
var ReactBootstrap = require('reactBootstrap');

class NavigationBar extends React.Component {
	render() {
		var navBarHeader = (
			<a href="/">
				<img src="/Content/images/2015-logo-inverted-small.png" alt="Global Azure Bootcamp 2015"/>
			</a>	
		);
		var Navbar = ReactBootstrap.Navbar;
		var NavItem = ReactBootstrap.NavItem;

		return (			
			<Navbar fixedTop={true} brand={navBarHeader}>
				<ReactBootstrap.Nav navbar right>
					<NavItem href='http://skg.azurebootcamp.net/' target='_blank'>Azure Bootcamp</NavItem>
					<NavItem href='https://github.com/xabikos/globalazurebootcampreport' target='_blank'>Github</NavItem>
				</ReactBootstrap.Nav>
			</Navbar>
		);
  }
}

module.exports = NavigationBar;