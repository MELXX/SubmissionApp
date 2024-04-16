import 'package:flutter/material.dart';
import 'package:flutter_application_1/Config/DefaultVars.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Group List',
      theme: ThemeData.dark(),
      home: GroupListWidget(),
    );
  }
}

class GroupListWidget extends StatefulWidget {
  @override
  _GroupListWidgetState createState() => _GroupListWidgetState();
}

class _GroupListWidgetState extends State<GroupListWidget> {
  List<Map<String, dynamic>> _groups = [];

  @override
  void initState() {
    super.initState();
    _fetchGroups();
  }

  Future<void> _fetchGroups() async {
    final response = await http.get(Uri.parse(DefaultVars.baseurl+'/Groups/list')); 
    if (response.statusCode == 200) {
      final List<dynamic> groupsJson = jsonDecode(response.body);
      setState(() {
        _groups = groupsJson.map((group) => Map<String, dynamic>.from(group)).toList();
      });
    } else {
      throw Exception('Failed to load groups');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Group List'),
      ),
      body: _groups.isEmpty
          ? Center(
              child: CircularProgressIndicator(),
            )
          : ListView.builder(
              itemCount: _groups.length,
              itemBuilder: (context, index) {
                final group = _groups[index];
                return ExpansionTile(
                  title: Text(group['name']),
                  children: [
                    ListTile(
                      title: Text('Users:'),
                    ),
                    ListView.builder(
                      shrinkWrap: true,
                      itemCount: group['users'].length,
                      itemBuilder: (context, userIndex) {
                        final user = group['users'][userIndex];
                        return ListTile(
                          title: Text('${user['name']} ${user['surname']}'),
                          subtitle: Text(user['email']),
                        );
                      },
                    ),
                    ListTile(
                      title: Text('Permissions:'),
                    ),
                    ListView.builder(
                      shrinkWrap: true,
                      itemCount: group['permissions'].length,
                      itemBuilder: (context, permissionIndex) {
                        final permission = group['permissions'][permissionIndex];
                        return ListTile(
                          title: Text(permission['name']),
                        );
                      },
                    ),
                  ],
                );
              },
            ),
    );
  }
}
